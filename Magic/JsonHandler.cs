using Newtonsoft.Json;

namespace Magic;

public class JsonHandler
{
    private readonly string _outputDataPath;
    private List<CardModel> _records;
    private readonly JsonSerializerSettings _jsonSerializerSettings;

    public JsonHandler(string outputDataPath, List<CardModel> records)
    {
        _jsonSerializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
        _outputDataPath = outputDataPath;
        _records = records;
    }

    public void Write()
    {
        var serializeObject = JsonConvert.SerializeObject(_records, _jsonSerializerSettings);
        File.WriteAllText(_outputDataPath, serializeObject);
    }
}
