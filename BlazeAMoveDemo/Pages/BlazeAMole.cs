using BlazeAMoveDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazeAMoveDemo.Pages
{
    public partial class BlazeAMole
    {
        private int score = 0;
        private int currenTime = 5;
        int hitPosition = 0;
        private string message = "";
        bool gameIsRunning = true;

        public List<SquareModel> Squares { get; set; } = new List<SquareModel>();

        public BlazeAMole()
        {
            for(int i=0; i<9; i++)
            {
                Squares.Add(new SquareModel
                {
                    Id = i
                });
            }
        }

        private void MouseUp(SquareModel s)
        {
            if(s.Id == hitPosition)
            {
                score += 1;
            }
        }

        private void ChooseSquare()
        {
            foreach(var item in Squares)
            {
                item.IsShown = false;
            }
            var randomPositon = new Random().Next(0, 9);
            Squares[randomPositon].IsShown = true;
            Console.WriteLine(randomPositon);
            hitPosition = randomPositon;
            StateHasChanged();
        }

        private async Task GameLoop()
        {
            while(gameIsRunning)
            {
                currenTime--;
                if(currenTime == 0)
                {
                    message = "EL JUEGO FINALIZÓ!";
                    gameIsRunning = false;
                }
                ChooseSquare();
                await Task.Delay(1000);
            }
        }

        protected override async void OnInitialized()
        {
            await GameLoop();
        }
    }
}
