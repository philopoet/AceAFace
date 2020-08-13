using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AceAFace.Common.EnumTypes;
using Framework.Domain;
using Framework.Game;

namespace AceAFace.Domain.PuzzleGames
{
    public class PictureNationalityPuzzle: Entity<int, PictureNationalityPuzzle>, IPuzzle<PictureNationalityPuzzleSolution>
    {
        private PictureNationalityPuzzle()
        {
            
        }
        public PictureNationalityPuzzle(
            string pictureUrl, 
            Nationality nationality)
        {
            PictureUrl = pictureUrl;
            Nationality = nationality;
            Histories = new List<PuzzleGameHistory>();
        }
        public string PictureUrl { get;private set; }
        [Column]
        private Nationality Nationality { get; set; }
        public ICollection<PuzzleGameHistory> Histories { get; private set; }
        public bool IsSolutionAccepted(PictureNationalityPuzzleSolution proposedSolution)
        {
           return Nationality == proposedSolution.Nationality;
        }
    }
}
