//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom
{
    using System;
    using System.Collections.Generic;
    
    public partial class Пользователи
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Пользователи()
        {
            this.Заявки = new HashSet<Заявки>();
        }
    
        public int ID_Пользователя { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public string ФИО { get; set; }
        public string Пол { get; set; }
        public System.DateTime Дата_рождения { get; set; }
        public string Гражданство { get; set; }
        public string Паспорт { get; set; }
        public string СНИЛС { get; set; }
        public string ИНН { get; set; }
        public string Мобильный_телефон { get; set; }
        public string Адрес_электронной_почты { get; set; }
        public string Почтовый_адрес { get; set; }
        public string Адрес_регистрации { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заявки> Заявки { get; set; }
    }
}
