using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCurPageController : MonoBehaviour, IGetCurPage
{
    IGetStoryData getStoryData;
    IGetCurNumPage getCurPageNum;
    private void Awake()
    {
        getStoryData = new GetStoryDataController();
        getCurPageNum = new GetCurNumPageController();
    }

    public Page Get() 
    {
        getStoryData = new GetStoryDataController();
        getCurPageNum = new GetCurNumPageController();
        int pageNum = getCurPageNum.Get();       
        return getStoryData.Get()[pageNum];
    }
}
