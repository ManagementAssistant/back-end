namespace BHA.ManagementAssistant.Nutritious.Model.Enums
{
    public enum HierarchyType
    {
        Robot = 0, //Job vs gibi entegre servislerin attığı kayıtlar
        Staff = 100, //En alt kademe 
        DM = 200, //Departman Yöneticisi
        Admin = 300, //Departmana ait bilgilerin tümünü görme yetkisine sahip verilen departman iznine göre
        GM = 400, //Firmanın en tepesindeki 
        BHA = 500
    }
}
