﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.EnitityLayer.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentDetail { get; set; }
        public string UserNameSurname { get; set; }

        //Hakaret içeren, istenmeyen yorumlar gosterilmez
        public bool IsValid { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int? ArticleId { get; set; }
        public Article? Article { get; set; }
        public float? ToxicityScore { get; set; }  // 0.0 - 1.0 arası

    }
}
