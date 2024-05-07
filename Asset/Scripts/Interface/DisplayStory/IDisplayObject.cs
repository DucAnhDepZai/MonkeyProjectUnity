using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDisplayObject 
{
    void Display(int pageNum, List<PageObject> pageObjects);
}
