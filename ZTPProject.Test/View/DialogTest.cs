using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZTPProject.View;

namespace ZTPProject.Test.View
{
    [TestClass]
    public class DialogTest
    {
        [TestMethod]
        public void Dialog()
        {
            BasicObjects.Dialog("Testtattre fddsjfsdjdfjs jsdfnjsdfjkdjksd nsdjkfnsdjkfnsdjkn " +
                "fnjksdnfjksdnfjkn sdfds jnfknsdjkfnsd jkfnsdjf njsdnfjksdnfjk dsjksd fjkTestt" +
                "s jnfknsdjkfnsd jkfnsjdfjs jsdfnjdfjs jsdfnjdfjsdjf njsdnfjksdnfjk dsjksd fjk", 7);
            BasicObjects.Dialog("Testtattre fdds", 1);
        }
    }
}
