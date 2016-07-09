using System.Collections.Generic;
using GeekDaysEdu.Models;

namespace GeekDaysEdu.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GeekDaysEdu.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GeekDaysEdu.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var categories = new CategoryModel[]
            {
                new CategoryModel()
                {
                    Name = "Машинное обучение"
                },
                new CategoryModel()
                {
                    Name = "Саморазвитие"
                },
                new CategoryModel()
                {
                    Name = "Веб"
                },
                new CategoryModel()
                {
                    Name = "Английский"
                }
            };
            context.CategoryModels.AddOrUpdate(c => c.Name, categories);

            context.SaveChanges();

            var courses = new ResourceModel[]
            {
                new ResourceModel
                {
                    Name = "Теория игр",
                    Type = "Курс",
                    URL = "https://www.coursera.org/learn/game-theory",
                    Disciption = "Чтобы проанализировать ту или иную реальную жизненную ситуацию стратегического взаимодействия и найти оптимальный вариант поведения в ней, необходимо сделать две вещи. Во-первых, необходимо формально записать ситуацию на языке теории игр, то есть создать модель (игру). Во-вторых, после того как модель (игра) составлена, ее необходимо решить. Этому мы будем учиться в течение курса. Мы разберем основные виды игр (одновременные и последовательные, с совершенной и несовершенной информацией, коалиционные и некоалиционные), приведем способы их решения и обсудим их на многочисленных примерах.",
                    LinkToImg = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://coursera-university-assets.s3.amazonaws.com/ef/731264341a445a36c4b42dbdb7ab7b/hse_color_kvadrat_white_e.png?auto=format&dpr=1&w=&h=72",
                    Category = categories[1],
                    Score = 9.0,
                    Tags = new List<string> {"Coursera", "Русский" }
                },
                new ResourceModel
                {
                    Name = "Машинное обучение",
                    Type = "Курс",
                    URL = "https://www.coursera.org/learn/machine-learning",
                    Disciption = "Machine learning is the science of getting computers to act without being explicitly programmed. In the past decade, machine learning has given us self-driving cars, practical speech recognition, effective web search, and a vastly improved understanding of the human genome. Machine learning is so pervasive today that you probably use it dozens of times a day without knowing it.",
                    LinkToImg = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/2a/34a150d9ad11e5bd22cb7d7d7686df/logo3.png?auto=format&dpr=1&w=100&h=100&fit=fill&bg=FFF",
                    Category = categories[0],
                    Score = 8.0,
                    Tags = new List<string> {"Coursera", "Английский" }
                },
                new ResourceModel
                {
                    Name = "English Grammar and Style",
                    Type = "Курс",
                    URL = "https://www.edx.org/course/english-grammar-style-uqx-write101x-2",
                    Disciption = "With the rise of social media and the Internet, many people are writing more today for different mediums than ever before. We’ll present materials that cover grammatical principles, word usage, writing style, sentence and paragraph structure, and punctuation.",
                    LinkToImg = "http://www.langmainternational.com/wp-content/uploads/2015/12/english1.png",
                    Category = categories[3],
                    Score = 8.5,
                    Tags = new List<string> {"Edx", "Английский" }
                },
                new ResourceModel
                {
                    Name = "Word Power Made Easy",
                    Type = "Книга",
                    URL = "https://www.amazon.com/Word-Power-Made-Easy-Vocabulary/dp/110187385X/",
                    Disciption = "Word Power Made Easy is the most effective vocabulary builder in the English language. It provides a simple, step-by-step method for increasing knowledge and mastery of written and spoken English.",
                    LinkToImg = "https://images-na.ssl-images-amazon.com/images/I/51kVjgX0C3L.jpg",
                    Category = categories[3],
                    Score = 8.5,
                    Tags = new List<string> {"Английский" }
                }
            };

            context.ResourceModels.AddOrUpdate(r => r.Name, courses);
            context.SaveChanges();
        }
    }
}
