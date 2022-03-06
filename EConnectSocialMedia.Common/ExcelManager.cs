
namespace EConnectSocialMedia.Common
{
    public class ExcelManager
    {
        private readonly string WebRootPath;

        public ExcelManager(string WebRootPath)
        {
            this.WebRootPath = WebRootPath;
        }

        public async Task<List<List<string>>> Import(
            IFormFile formFile,
            int rowStart = 1,
            int ColStart = 1,
            int rowEnd = 0,
            int ColEnd = 0)
        {
            if (formFile == null || formFile.Length <= 0)
            {
                return null;
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            List<List<string>> Data = new();

            using (MemoryStream stream = new())
            {
                await formFile.CopyToAsync(stream);

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


                using (ExcelPackage package = new(stream))
                {
                    ExcelWorksheets Worksheets = package.Workbook.Worksheets;
                    ExcelWorksheet Worksheet = Worksheets.First();

                    int noOfCol = ColEnd == 0 ? Worksheet.Dimension.End.Column : ColEnd;
                    int noOfRow = rowEnd == 0 ? Worksheet.Dimension.End.Row : rowEnd;
                    int i = 0;

                    for (int rowIterator = rowStart; rowIterator <= noOfRow; rowIterator++)
                    {
                        Data.Add(new List<string>());

                        for (int colIterator = ColStart; colIterator <= noOfCol; colIterator++)
                        {
                            if (true || Worksheet.Cells[rowIterator, colIterator].Value != null)
                            {
                                Data[i].Add(Worksheet.Cells[rowIterator, colIterator].Value == null ? "" : Worksheet.Cells[rowIterator, colIterator].Value.ToString());
                            }
                        }
                        i++;
                    }
                }
            }

            return Data;
        }

        public async Task<string> Export<T>(List<T> Data, string DomainName, string FileName, string FolderURL)
        {
            string FilePath = $"/{FolderURL}/{FileName}.xlsx";

            string FullPath = WebRootPath + FilePath;

            FileInfo file = new(FullPath);

            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(FullPath);
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage Package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = Package.Workbook.Worksheets.Add(FileName);

                worksheet.DefaultColWidth = 25;

                worksheet.Cells.LoadFromCollection(Data, true, TableStyles.Medium1);
                await Package.SaveAsync();
            }

            return DomainName + "/" + FilePath;
        }
    }
}
