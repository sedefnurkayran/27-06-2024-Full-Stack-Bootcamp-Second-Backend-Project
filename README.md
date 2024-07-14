# 27-06-2024-Full-Stack-Bootcamp-Second-Backend-Project
In this project, search, filtering, uploading files, adding, deleting and updating bootcamps were performed.  Tag helper and validations were used.

string.Empty: Bos olamaz. hic bir sey yazmazsak null veri gider.
Static: disardan da okunabilir hale gelir, void kavramlari
IEnumarable<Produc> ve List<Product>: Aynidir. Listedeki ürünleri ceker.
Search islemi: public IActionResult Index(string q) ile ifade edilir.
products = products.Where(p => p.Name!.ToLower().Contains(searchString)).ToList(); //Name hic bir zaman bos olmayacak diyoruz. Ve her zaman büyük veya kücük harfe cevirmemiz gerek aranan ifadeyi.

ViewBag:Gecici veri depolar ve tasir.  
ViewModel: ViewBag yöntemi ile veri tasimak cok güvenli olmadigi icin ViewModel kullanilir. 

SelectList: List ten farkli olarak Select Formunda verileri gostermek icin kullanilir. 
Get ve Post Metodlari
Post: Her zaman model ister.
Tag Helper: Labelin ici bos olsa da (<label asp-for="Name" class="form-label"></label>)  tag helper([Display(Name = "Bootcamp Adı")]) kullaniyorsak aciklama gorunur.Verdigimiz validasyonlari gecerli kildik.
  <select class="form-select" asp-items="@(new SelectList(Model.Categories, "CategoryId","Name",Model.SelectedCategory))" name="category">
                        <option value="0">Hepsi</option>
  </select> BUrada asp-items kullanarak foreach yapisini kullanmamis olduk.
  
StringLength: Parolalar icin kullanilir.  [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
Validasyonlar
if(ModelState.IsValid)
<span asp-validation-for=""></span>
<div asp-validation-summary="All"></div>

Data Seeding:


Yükleme yaparken ModelBinding ve Veri Eslestirme Yöntemi Kullanilir.
p=>pName! : Name icin bos deger gelmeyecek demek.
enctype="multipart/form-data": Sadece dosya yüklerken kullaniliyor.
IFormFile: Dosya IFrame dir.

Asyn metodlar: Ayni anda islem yapabilmek icin.
Catch: Istisnalari atar. Parametre alir.


