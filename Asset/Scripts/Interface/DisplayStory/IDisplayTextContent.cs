using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDisplayTextContent 
{
    void Display(int pageNum, List<Word> sentences);
}
