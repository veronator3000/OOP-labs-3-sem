    using Itmo.ObjectOrientedProgramming.Lab3.Entities.Exceptions;

    namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

    public class Message
    {
        public Message(
            string title,
            string body,
            int importanceLevel)
        {
            if (importanceLevel < 0) throw new NegativeValueException();
            Title = title;
            Body = body;
            ImportanceLevel = importanceLevel;
        }

        public string Title { get; }
        public string Body { get; }
        public int ImportanceLevel { get; }
    }