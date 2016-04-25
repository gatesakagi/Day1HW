using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day1HW.Models.ViewModels
{
    public class AccountContentViewModel : IValidatableObject
    {
        [DisplayName("分類")]
        [Required(ErrorMessage ="必須選擇分類")]
        public int accountCategory { get; set; }

        [DisplayName("金額")]
        [Required(ErrorMessage ="必須填寫金額")]
        [Range(1, int.MaxValue, ErrorMessage = "只能輸入不為零的正整數")]
        public decimal accountFee { get; set; }

        [DisplayName("日期")]
        [Required(ErrorMessage ="必須填寫日期")]
        public DateTime accountDate { get; set; }

        [DisplayName("備註")]
        [Required(ErrorMessage ="必須填寫備註")]
        [StringLength(100, ErrorMessage ="填寫字數最多100個")]
        public string accountNote { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (accountDate > DateTime.Now)
            {
                yield return new ValidationResult("日期不得為未來！", new[] { "accountDate" });
            }
        }

    }
}