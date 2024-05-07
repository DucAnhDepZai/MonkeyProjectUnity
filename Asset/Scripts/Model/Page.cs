
using System.Collections.Generic;

public class Page : BasePage
{

    public override void SetOrder(int order)
    {
        this.order = order;
    }

    public override int GetOrder()
    {
        return order;
    }

    public override List<PageObject> GetPageObjects()
    {
        return this.pageObjets;
    }

    public override void SetPageObjects(List<PageObject> pageObjects)
    {
        this.pageObjets = pageObjects;
    }

    public override List<Word> GetSentences()
    {
        return this.sentences;
    }

    public override void SetSentences(List<Word> sentences)
    {
        this.sentences = sentences;
    }

    public override List<Blink> GetBlinks()
    {
        return this.blinks;
    }

    public override void SetBlinks(List<Blink> blinks)
    {
        this.blinks = blinks;
    }

    public override string GetBgPath()
    {
        return this.bgPath;
    }

    public override void SetBgPath(string bgPath)
    {
        this.bgPath = bgPath;
    }
}
