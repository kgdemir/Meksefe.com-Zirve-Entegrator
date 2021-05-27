using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Meksefe.com_Zirve_Entegrator
{
    public class Helper
    {

        public class ErrorResponse
        {
            public string error { get; set; }
            public string error_description { get; set; }
        }

        public class TokenResponse
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public string UygulamaId { get; set; }
            public string BayiKodu { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string KullaniciAdi { get; set; }
            public string Telefon { get; set; }
            public DateTime TimeOfLogin { get; set; } = DateTime.MinValue;
            private DateTime _validuntil = DateTime.MinValue;
            public DateTime ValidUntil
            {
                get
                {
                    if (TimeOfLogin > DateTime.MinValue && _validuntil == DateTime.MinValue)
                    {
                        _validuntil = TimeOfLogin.AddSeconds(expires_in);
                    }
                    return _validuntil;
                }
            }
            public bool Valid
            {
                get
                {
                    if (ValidUntil > DateTime.Now && token_type?.Length > 3 && access_token?.Length > 10)
                        return true;
                    return false;
                }
            }
        }

        public class Response<T>
        {
            public bool HasError { get; set; }
            public string Msg { get; set; }
            public List<T> Obj { get; set; }

        }
        public class IsEmri
        {
            public int Id { get; set; }
            public string IdGuid { get; set; }
            public int KayitSekliId { get; set; }
            public int HizmetId { get; set; }
            public int DurumId { get; set; }
            public int? DurumDetayId { get; set; }
            public string Plaka { get; set; }
            public string Sasi { get; set; }
            public int KM { get; set; }
            public string MusteriId { get; set; }
            public string MusteriAdSoyad { get; set; }
            public string MusteriUnvan { get; set; }
            public string MusteriTelefon { get; set; }
            public string MusteriEMail { get; set; }
            public int ModelYili { get; set; }
            public object AracTip { get; set; }
            public string MarkaId { get; set; }
            public string Marka { get; set; }
            public string ModelId { get; set; }
            public string Model { get; set; }
            public string Yakit { get; set; }
            public string Kasa { get; set; }
            public string Vites { get; set; }
            public string Versiyon { get; set; }
            public string MotorKodu { get; set; }
            public int MotorGucuHP { get; set; }
            public string AracRefId { get; set; }
            public string AracAppId { get; set; }
            public string AracAppId2 { get; set; }
            public int DanismanId { get; set; }
            public object RandevuTarih { get; set; }
            public DateTime? TeslimTarihi { get; set; }
            public DateTime IsEmriBaslangicTarihi { get; set; }
            public string IsEmriNot { get; set; }
            public string IsEmriIcNot { get; set; }
            public object IptalSebep { get; set; }
            public bool AktifKayit { get; set; }
            public int Kaydeden { get; set; }
            public DateTime KayitTarihi { get; set; }
            public int Guncelleyen { get; set; }
            public DateTime GuncellemeTarihi { get; set; }
            public string DanismanAd { get; set; }
            public string DanismanSoyad { get; set; }
            public DateTime FaturaTarihi { get; set; }
        }

        
        public class FaturaObj
        {
            public IsEmri IsEmri { get; set; }
            public object Sigorta { get; set; }
            public Sikayet[] Sikayet { get; set; }
            public Talep[] Talep { get; set; }
            public object[] Parca { get; set; }
            public object MusteriDetay { get; set; }
            public Fatura Fatura { get; set; }
            public Faturadetay[] FaturaDetay { get; set; }
        }

        public class Fatura
        {
            public int Id { get; set; }
            public string IsEmriIdGuid { get; set; }
            public string IdGuid { get; set; }
            public float Tutar { get; set; }
            public float IndirimOran { get; set; }
            public float IndirimTutar { get; set; }
            public float ToplamTutar { get; set; }
            public float KDVOran { get; set; }
            public float KDVTutar { get; set; }
            public float FaturaTutar { get; set; }
            public float YuvarlamaFark { get; set; }
            public bool FaturaIstenmiyor { get; set; }
            public object FaturaSeriNo { get; set; }
            public object FaturaTarihi { get; set; }
            public bool AktifKayit { get; set; }
            public DateTime KayitTarihi { get; set; }
            public DateTime GuncellemeTarihi { get; set; }
            public string PersonelAd { get; set; }
            public string PersonelSoyad { get; set; }
        }

        public class Sikayet
        {
            public int Id { get; set; }
            public string IsEmriIdGuid { get; set; }
            public string IdGuid { get; set; }
            public int TipId { get; set; }
            public string Aciklama { get; set; }
            public float Tutar { get; set; }
            public float KDVOran { get; set; }
            public float KDVTutar { get; set; }
            public float IndirimOran { get; set; }
            public float IndirimTutar { get; set; }
            public float ToplamTutar { get; set; }
            public float FaturaTutar { get; set; }
            public bool AktifKayit { get; set; }
            public int Kaydeden { get; set; }
            public DateTime KayitTarihi { get; set; }
            public int Guncelleyen { get; set; }
            public DateTime GuncellemeTarihi { get; set; }
        }

        public class Talep
        {
            public int Id { get; set; }
            public string IsEmriIdGuid { get; set; }
            public string IdGuid { get; set; }
            public string Aciklama { get; set; }
            public bool AktifKayit { get; set; }
            public int Kaydeden { get; set; }
            public DateTime KayitTarihi { get; set; }
            public int Guncelleyen { get; set; }
            public DateTime GuncellemeTarihi { get; set; }
        }

        public class Faturadetay
        {
            public int Id { get; set; }
            public int UygulamaId { get; set; }
            public int BayiId { get; set; }
            public string FaturaIdGuid { get; set; }
            public string IdGuid { get; set; }
            public string SatirTipi { get; set; }
            public object ParcaKodu { get; set; }
            public string Aciklama { get; set; }
            public object PaketId { get; set; }
            public bool IsPaket { get; set; }
            public float Adet { get; set; }
            public float AlisFiyat { get; set; }
            public float SatisFiyat { get; set; }
            public float BirimFiyat { get; set; }
            public float Tutar { get; set; }
            public float IndirimOran { get; set; }
            public float IndirimTutar { get; set; }
            public float ToplamTutar { get; set; }
            public float KDVOran { get; set; }
            public float KDVTutar { get; set; }
            public float FaturaTutar { get; set; }
            public bool AktifKayit { get; set; }
            public DateTime KayitTarihi { get; set; }
            public DateTime GuncellemeTarihi { get; set; }
            public string PersonelAd { get; set; }
            public string PersonelSoyad { get; set; }
        }


        public const string BASE_URL = "https://service.meksefe.com/api";

        public static TokenResponse CurrentUser { get; set; }
        public async static Task<Response<IsEmri>> GetIsEmriList()
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent("{DurumId: 500, Pasif: false}", Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CurrentUser.access_token);
                using (var response = await httpClient.PostAsync($"{BASE_URL}/IsEmri/Listele", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Response<IsEmri>>(apiResponse);
                }
            }
        }
        public async static Task<Response<FaturaObj>> GetFaturaDetay(Guid Id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CurrentUser.access_token);
                using (var response = await httpClient.GetAsync($"{BASE_URL}/IsEmri/FormGetir/{Id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Response<FaturaObj>>(apiResponse);
                }
            }
        }

        public async static Task Login(string user, string pass)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent($"UserName={user}&Password={pass}&grant_type=password");
                    using (var response = await httpClient.PostAsync($"{BASE_URL}/token", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        CurrentUser = JsonSerializer.Deserialize<TokenResponse>(apiResponse);
                        if (string.IsNullOrEmpty(CurrentUser?.access_token))
                        {
                            var error = JsonSerializer.Deserialize<ErrorResponse>(apiResponse);
                            if (string.IsNullOrEmpty(error?.error_description))
                            {
                                throw new Exception("Bilinmeyen hata!");
                            }
                            throw new Exception(error.error_description);
                        }
                        CurrentUser.TimeOfLogin = DateTime.Now;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
