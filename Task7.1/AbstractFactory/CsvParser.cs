using System.Globalization;

namespace AbstractLibraryTask
{
    public class CsvParser
    {
        private readonly string filePath;
        private readonly LibraryType libraryType;

        public CsvParser(string filePath, LibraryType libraryType)
        {
            this.filePath = filePath;
            this.libraryType = libraryType;
        }

        public List<EBook> ParseEBooks()
        {
            List<EBook> eBooks = new List<EBook>();

            foreach (var row in ReadCsvFile())
            {
                EBook eBook = CreateEBookFromCsvRow(row);
                if (eBook != null)
                {
                    eBooks.Add(eBook);
                }
            }

            return eBooks;
        }

        public List<PaperBook> ParsePaperBooks()
        {
            List<PaperBook> paperBooks = new List<PaperBook>();

            foreach (var row in ReadCsvFile())
            {
                PaperBook paperBook = CreatePaperBookFromCsvRow(row);
                if (paperBook != null)
                {
                    paperBooks.Add(paperBook);
                }
            }

            return paperBooks;
        }

        public List<string> GetPressReleaseItems()
        {
            var pressReleaseItems = new HashSet<string>();

            foreach (var row in ReadCsvFile())
            {
                // Extract publisher for PaperBook
                if (libraryType == LibraryType.PaperBook && row.TryGetValue("publisher", out var publisher))
                {
                    pressReleaseItems.Add(publisher);
                }

                // Extract formats for EBook
                if (libraryType == LibraryType.EBook && row.TryGetValue("format", out var formats))
                {
                    var formatList = SplitCsvLine(formats).Select(f => f.Trim()).ToList();
                    pressReleaseItems.UnionWith(formatList);
                }
            }

            return pressReleaseItems.ToList();
        }

        private Dictionary<string, string> ReadCsvRow(string line)
        {
            var columns = SplitCsvLine(line);
            var rowData = new Dictionary<string, string>();

            for (int i = 0; i < columns.Length; i++)
            {
                var key = i < BookCsvColumns.Count ? BookCsvColumns[i] : $"Column{i + 1}";
                rowData[key] = columns[i];
            }

            return rowData;
        }

        private IEnumerable<Dictionary<string, string>> ReadCsvFile()
        {
            var lines = File.ReadAllLines(filePath);

            // Skip the first row (header) and parse each line
            return lines.Skip(1).Select(ReadCsvRow);
        }

        private EBook CreateEBookFromCsvRow(Dictionary<string, string> row)
        {
            var eBook = new EBook();

            ExtractCommonBookAttributes(row, eBook);

            // Extract eBook specific attributes
            if (row.TryGetValue("format", out var formats))
            {
                eBook.Formats = SplitCsvLine(formats).Select(f => f.Trim()).ToList();
            }

            if (row.TryGetValue("identifier", out var identifier) && !string.IsNullOrWhiteSpace(identifier))
            {
                eBook.ResourceIdentifier = new List<string> { identifier };
                eBook.Identifier = identifier;
            }
            else
            {
                // Skip EBook without identifier
                return null;
            }

            return eBook;
        }

        private PaperBook CreatePaperBookFromCsvRow(Dictionary<string, string> row)
        {
            var paperBook = new PaperBook();

            ExtractCommonBookAttributes(row, paperBook);

            // Extract PaperBook specific attributes
            if (row.TryGetValue("publisher", out var publisher))
            {
                paperBook.Publisher = publisher;
            }

            if (row.TryGetValue("relatedexternalid", out var relatedExternalIds) && !string.IsNullOrWhiteSpace(relatedExternalIds))
            {
                var isbnList = SplitCsvLine(relatedExternalIds).Select(id => id.Trim()).ToList();
                if (isbnList.Any())
                {
                    paperBook.ISBNs = isbnList;
                    paperBook.Identifier = isbnList.First(); // Use the first ISBN as identifier
                }
                else
                {
                    return null;
                }
            }
            else
            {
                // Skip PaperBook without relatedexternalid
                return null;
            }

            return paperBook;
        }

        private void ExtractCommonBookAttributes(Dictionary<string, string> row, Book book)
        {
            if (row.TryGetValue("title", out var title))
            {
                book.Title = title;
            }

            if (row.TryGetValue("publicdate", out var publicDate) && DateTime.TryParseExact(
                publicDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var parsedDate))
            {
                book.PublicationDate = parsedDate;
            }

            if (row.TryGetValue("creator", out var creators))
            {
                var authorList = ExtractAuthors(creators);
                book.Authors = authorList.Select(author =>
                    new Author
                    {
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                        DateOfBirth = author.DateOfBirth
                    }).ToList();
            }
        }

        private List<Author> ExtractAuthors(string creators)
        {
            var authorList = new List<Author>();
            var authorEntries = SplitCsvLine(creators);

            for (int i = 0; i < authorEntries.Length; i += 3)
            {
                var lastName = authorEntries[i].Trim();
                var firstName = i + 1 < authorEntries.Length ? authorEntries[i + 1].Trim() : null;
                var dateOfBirth = i + 2 < authorEntries.Length ? ExtractDateOfBirth(authorEntries.Skip(i + 2).ToArray()) : null;

                // Ignore entries with "ill" in them
                if (!string.IsNullOrWhiteSpace(lastName) && !string.Equals(lastName.Trim(), "ill", StringComparison.OrdinalIgnoreCase))
                {
                    var author = new Author
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateOfBirth
                    };

                    authorList.Add(author);
                }
            }

            return authorList;
        }

        private int? ExtractDateOfBirth(string[] parts)
        {
            if (parts.Length > 0)
            {
                var datePart = parts[0].Trim();

                if (!string.IsNullOrWhiteSpace(datePart) && !datePart.Equals("ill", StringComparison.OrdinalIgnoreCase))
                {
                    if (datePart.Contains('-'))
                    {
                        if (int.TryParse(datePart.Split('-')[0], out var birthYear))
                        {
                            return birthYear;
                        }
                    }
                    else if (int.TryParse(datePart, out var birthYear))
                    {
                        return birthYear;
                    }
                }
            }

            return null;
        }

        private string[] SplitCsvLine(string line)
        {
            var result = new List<string>();
            var inQuotes = false;
            var currentToken = "";

            foreach (char c in line)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(currentToken);
                    currentToken = "";
                }
                else
                {
                    currentToken += c;
                }
            }

            result.Add(currentToken);
            return result.ToArray();
        }

        private static readonly List<string> BookCsvColumns = new List<string>
        {
            "creator", "format", "identifier", "publicdate", "publisher", "relatedexternalid", "title"
        };
    }
}