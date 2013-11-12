using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Caliburn.Micro;

namespace InstantBingo.Result
{
    public class AddCreditsResult : IResult
    {
        public void Execute(CoroutineExecutionContext context)
        {
            var view = (FrameworkElement)context.View;            
            var storyboard = (Storyboard)view.Resources["AddCreditsStoryboard"];
            storyboard.Begin();
        }

        public event EventHandler<ResultCompletionEventArgs> Completed;
    }
}
