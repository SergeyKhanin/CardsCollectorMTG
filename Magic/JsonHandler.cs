using Newtonsoft.Json;

namespace Magic;

public class JsonHandler
{
    private readonly string _outputDataPath;
    private List<CardModel> _records;

    public JsonHandler(string outputDataPath, List<CardModel> records)
    {
        _outputDataPath = outputDataPath;
        _records = records;
    }

    public void Write()
    {
        var serializeObject = JsonConvert.SerializeObject(_records);
        File.WriteAllText(_outputDataPath, serializeObject);
    }
}
