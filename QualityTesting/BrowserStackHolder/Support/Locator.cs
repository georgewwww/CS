using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrowserStackHolder.Support
{
    public class Locator
    {
        public Element Element { get; private set; }
        public By FindBy { get; private set; }

        public Locator(Element element, By findBy)
        {
            Element = element;
            FindBy = findBy;
        }
    }
}
