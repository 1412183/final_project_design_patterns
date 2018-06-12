using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleValidationLibrary.Util
{
    public class TextBlockErrorBindingCarrier : ErrorBindingCarrier
    {
        public TextBlockErrorBindingCarrier(TextBlock textBlock, string propertyName) : base(textBlock, propertyName) { }
        protected override void SetTargetValue(string errorMessage)
        {
            dynamic textBlock = this._target;
            textBlock.Text = errorMessage;
        }
    }
}
