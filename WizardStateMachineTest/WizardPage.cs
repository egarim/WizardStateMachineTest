using System;
using System.Linq;

namespace WizardExample
{
    // Base classes from the blog post
    public class WizardPage
    {
        public int Index { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; } = true;
        public bool IsCompleted { get; set; }
        public object Content { get; set; }

        public WizardPage(int index, string title)
        {
            Index = index;
            Title = title;
        }

        public virtual bool Validate()
        {
            // Default implementation assumes page is valid
            return true;
        }
    }
}
