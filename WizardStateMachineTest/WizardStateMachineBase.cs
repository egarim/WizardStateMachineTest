using System;
using System.Linq;

namespace WizardExample
{
    public class WizardStateMachineBase
    {
        protected readonly List<WizardPage> _pages;
        protected int _currentIndex;

        public WizardStateMachineBase(IEnumerable<WizardPage> pages)
        {
            _pages = pages.OrderBy(p => p.Index).ToList();
            _currentIndex = 0;
        }

        public event EventHandler<StateTransitionEventArgs> StateTransition;

        public WizardPage CurrentPage => _pages.Count > 0 ? _pages[_currentIndex] : null;

        public bool IsFirstPage => _currentIndex == 0;

        public bool IsLastPage => _currentIndex == _pages.Count - 1;

        public virtual bool MoveNext()
        {
            if (_pages.Count == 0 || _currentIndex >= _pages.Count - 1)
                return false;

            var args = new StateTransitionEventArgs(CurrentPage, _pages[_currentIndex + 1]);
            OnStateTransition(args);

            if (!args.Cancel)
            {
                _currentIndex++;
                return true;
            }

            return false;
        }

        public virtual bool MovePrevious()
        {
            if (_pages.Count == 0 || _currentIndex <= 0)
                return false;

            var args = new StateTransitionEventArgs(CurrentPage, _pages[_currentIndex - 1]);
            OnStateTransition(args);

            if (!args.Cancel)
            {
                _currentIndex--;
                return true;
            }

            return false;
        }

        protected virtual void OnStateTransition(StateTransitionEventArgs e)
        {
            StateTransition?.Invoke(this, e);
        }
    }
}
