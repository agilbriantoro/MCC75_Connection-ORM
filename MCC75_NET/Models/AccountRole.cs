using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCC75_NET.Models
{
    [Table("tb_tr_Account_Roles")]
    public class AccountRole
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Required, Column("account_nik"), MaxLength(5)]
        public string AccountNik { get; set; }
        [Required, Column("roleid")]
        public int RoleId { get; set; }

        //Relasi
        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }
        [ForeignKey(nameof(AccountNik))]
        public Account? Account { get; set; }
    }
}
