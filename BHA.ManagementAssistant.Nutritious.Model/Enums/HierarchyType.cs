namespace BHA.ManagementAssistant.Nutritious.Model.Enums
{
    public enum HierarchyType
    {
        Robot = 0, //Job vs gibi entegre servislerin attığı kayıtlar
        Staff = 100, //İşçi (Çevre Mühendisi) ---Sadece kendi datasını görebilir
        DM = 200, //Departman Yöneticisi (Örn: Muhasebe, Çevre Mühendisleri takım lideri) --Sadece kendine bağlı birimin datalarını görebilir.
        Admin = 300, //Kendisine izni verilen departmanlara ait tüm bilgileri görebilir.
        GM = 400, //Firmanın en tepesindeki, Tüm dataları görme yetkisine sahip fakat sadece kendi oluşturduğu dataları düzenleme yetkisi var(Tüm yetkiler için bu durum geçerlidir).
        BHA = 500
    }
}