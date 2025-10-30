using DocomoCsJavaBridge.Aspects;

namespace LaytonMotdm2.c;

[ClassName("c", "x")]
public interface IScene
{
    [FunctionName("a")]
    void Setup(GameContext gameContext);

    [FunctionName("b")]
    bool Update(GameContext gameContext);

    [FunctionName("c")]
    void Reset(GameContext paramy);
}
