using System;

namespace QuestLog.Models
{
    public class Objective
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public ObjectiveType Category { get; set; }
    }
}