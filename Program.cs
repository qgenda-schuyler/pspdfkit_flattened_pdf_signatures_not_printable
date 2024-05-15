using GdPicture14;
using GdPicture;

LicenseManager licenseManager = new LicenseManager();
licenseManager.RegisterKEY("");

using (var basePdfStream = new MemoryStream(File.ReadAllBytes("Document.pdf")))
using (var jsonStream = new MemoryStream(File.ReadAllBytes("json.json")))
using (var outputPdfStream = new FileStream("FlattenedDocument.pdf", FileMode.Create, FileAccess.Write))
using (var basePdf = new GdPicturePDF())
{
    GdPictureStatus result = basePdf.LoadFromStream(basePdfStream);

    result = basePdf.ImportInstantJSONDataFromStream(jsonStream);

    result = basePdf.FlattenFormFields();

    result = basePdf.SaveToStream(outputPdfStream);
}