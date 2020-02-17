using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmScreen.Models
{
    public class Movie
    {
        public Movie()
        {
            ReleaseDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Display(Name = "タイトル")]
        [Required(ErrorMessage = "タイトルを入力してください。")]
        public string Title { get; set; }

        [Display(Name = "感想")]
        public string Impression { get; set; }

        [Display(Name = "公開日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "ジャンルを入力してください。")]
        [Display(Name = "ジャンル")]
        public string Genre { get; set; }

        [Range(1, 10000)]
        [Display(Name = "値段")]
        [DataType(DataType.Currency, ErrorMessage = "値段のみ入力してください。")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5, ErrorMessage = "半角アルファベット5文字以内で入力してください。")]
        [Required(ErrorMessage = "入力必須です")]
        [Display(Name = "レーティング")]
        public string Rating { get; set; }

    }







}
