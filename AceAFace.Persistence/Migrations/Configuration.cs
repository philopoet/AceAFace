using AceAFace.Common.EnumTypes;
using AceAFace.Domain.PuzzleGames;
using Pap.WebPushManagement.Infrastructure.Persistence;

namespace AceAFace.Persistence.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pap.WebPushManagement.Infrastructure.Persistence.AceAFaceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

        }

        protected override void Seed(Pap.WebPushManagement.Infrastructure.Persistence.AceAFaceContext context)
        {
            context.PictureNationalityPuzzles.AddOrUpdate(x => x.Id,
                new PictureNationalityPuzzle("2201", Nationality.Chinese),
                new PictureNationalityPuzzle("2202", Nationality.Chinese),
                new PictureNationalityPuzzle("2203", Nationality.Japanese),
                new PictureNationalityPuzzle("2204", Nationality.Japanese),
                new PictureNationalityPuzzle("2205", Nationality.Korean),
                new PictureNationalityPuzzle("2206", Nationality.Chinese),
                new PictureNationalityPuzzle("2207", Nationality.Japanese),
                new PictureNationalityPuzzle("2208", Nationality.Korean),
                new PictureNationalityPuzzle("2209", Nationality.Chinese),
                new PictureNationalityPuzzle("2210", Nationality.Korean),
                new PictureNationalityPuzzle("2211", Nationality.Thai),
                new PictureNationalityPuzzle("2212", Nationality.Korean),
                new PictureNationalityPuzzle("2213", Nationality.Japanese),
                new PictureNationalityPuzzle("2214", Nationality.Chinese),
                new PictureNationalityPuzzle("2215", Nationality.Thai),
                new PictureNationalityPuzzle("2216", Nationality.Korean),
                new PictureNationalityPuzzle("2217", Nationality.Japanese),
                new PictureNationalityPuzzle("2218", Nationality.Thai),
                new PictureNationalityPuzzle("2219", Nationality.Thai),
                new PictureNationalityPuzzle("2220", Nationality.Japanese),
                new PictureNationalityPuzzle("2221", Nationality.Thai));

        }
    }
}
