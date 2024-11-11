﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Cores.Entities
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The event name can not be left empty")]
        public string Name { get; set; } = string.Empty;

        public string PosterURL { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The event description can not be left empty")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event ticket price can not be empty")]
        public long Price { get; set; }

        [Required(ErrorMessage = "Event start date can not be empty")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Event end date can not be empty")]
        public DateTime EndDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Event capacity is required")]
        public int Capacity { get; set; } = 0;

        [Required(ErrorMessage = "Club is required")]
        [ForeignKey(nameof(Club))]
        public Guid ClubId {  get; set; }

        public virtual Club Club { get; set; } = null!;

        public virtual IEnumerable<EventRegistration> EventRegistrations { get; set; } = Enumerable.Empty<EventRegistration>();
    }
}
