using GdPicture14;
using GdPicture;

LicenseManager licenseManager = new LicenseManager();
licenseManager.RegisterKEY("XXXXXXXX");

using (var outputPdfStream = new MemoryStream())
using (var basePdfStream = new MemoryStream(File.ReadAllBytes("Document.pdf")))
using (var jsonStream = new MemoryStream(File.ReadAllBytes("json.json")))
using (var fileStream = new FileStream("DocumentWithJson.pdf", FileMode.Create, FileAccess.Write))
using (var basePdf = new GdPicturePDF())
{
    GdPictureStatus result = basePdf.LoadFromStream(basePdfStream);

    result = basePdf.ImportInstantJSONDataFromStream(jsonStream);

    result = basePdf.SaveToStream(outputPdfStream);

    outputPdfStream.CopyTo(fileStream);
}