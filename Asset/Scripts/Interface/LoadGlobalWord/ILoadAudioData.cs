using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ILoadAudioData
{  Audio LoadData(JSONNode audioDatas, string prePath);
}
