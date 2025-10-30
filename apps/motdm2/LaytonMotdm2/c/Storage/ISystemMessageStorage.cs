using DocomoCsJavaBridge.Aspects;
using java.lang;

namespace LaytonMotdm2.c.Storage;

[ClassName("c", "u")]
public interface ISystemMessageStorage
{
    [MemberName("o")]
    public static JavaString[][] Messages = new JavaString[][]
    {
      new JavaString[]{
          "◆DENAのダウンロード[br][br]DENAをダウンロードします。[br]ご利用には約２Mbyte以上の空きの[br]あるmicroSDカードが必要です。[br]また、大容量のデータをダウンロード[br]しますので、パケット定額サービスの[br]加入を強くお勧め致します。[br][br]　　　ダウンロードしますか？[end]", "はい", "いいえ"
      },
      new JavaString[]{
          "◆エラー[br][br]電池残量が少ないです。[br]ダウンロード中に電池が切れる可能性[br]があります。[br]ACアダプタをつないだ状態にするか、[br]充電後にダウンロードして下さい。[end]", "リトライ", "アプリ終了"
      },
      new JavaString[]{
          "◆エラー[br][br]通信中にエラーが発生しました。[br]電波状況や、アプリの設定をご確認[br]下さい。[end]", "リトライ", "アプリ終了"
      },
      new JavaString[]{
          "◆エラー[br][br]microSD読み込み中にエラーが発生[br]しました。[br]決定キーでアプリを終了し、microSD[br]を確認して下さい。[end]", null, null
      },
      new JavaString[]{
          "◆エラー[br][br]microSD書き込み中にエラーが発生[br]しました。[br]決定キーでアプリを終了し、microSD[br]を確認して下さい。[end]", null, null
      },
      new JavaString[]{
          "◆エラー[br][br]microSDが挿入されていません。[br]決定キーでアプリを終了し、[br]microSDを確認して下さい。[br][br]※microSDが挿入されているにも[br]　かかわらずこのエラーが出る場合、[br]　microSD内のデータが壊れている[br]　可能性があります。[br]　microSDを確認して下さい。[end]", null, null
      },
      new JavaString[]{
          "◆エラー[br][br]microSDの空き容量が足りません。[br]約２Mbyte以上の空き容量がある[br]状態で、ダウンロードして下さい。[end]", null, null
      },
      new JavaString[]{
          "◆再ダウンロード[br][br]前回起動時にエラーが発生しました。[br]データがダウンロード途中か、データ[br]が壊れている可能性があります。[br][br][br]　　　再ダウンロードしますか？[end]", "はい", "いいえ"
      },
      new JavaString[]{
          "◆確認結果[br][br]ソフト設定項目のアイコン情報設定を[br]「利用する」にして下さい。[br]決定キーでアプリを終了します。[end]", null, null
      },
      new JavaString[]{
          "◆非会員エラー[br][br]非会員の為、本アプリをプレイする事が[br]出来ません。[br]「ﾚｲﾄﾝ教授ﾓﾊﾞｲﾙ」で会員登録をした後、[br]もう一度アプリを起動してください。[br]会員登録すると、他のさまざまな[br]コンテンツも遊べるようになります。[br][br]「ﾚｲﾄﾝ教授ﾓﾊﾞｲﾙ」に接続しますか？[end]", "はい", "いいえ"
      },
      new JavaString[]{
          "引き続きプレイするには[br]モバイルポイントが必要です。[br]モバイルピカラットを消費して、[br]次の章を購入しますか？[br][br][br]　　　　【現在のモバイルピカラット】[br]　　　　　　　　　　＞ポイント[end]", "はい", "いいえ"
      },
      new JavaString[]{
          "引き続きプレイするには[br]モバイルポイントが必要です。[br]サイトへ接続して、モバイルピカラット[br]を追加購入しますか？[br][br][br]　　　　【現在のモバイルピカラット】[br]　　　　　　　　　　＞ポイント[end]", "はい", "いいえ"
      },
      new JavaString[]{
          "◆サーバーメンテナンス中[br][br]現在サーバーメンテナンス中です。[br]ご迷惑をおかけいたしますが、[br]しばらく経ってから[br]アプリを起動していただくよう、[br]お願い致します。[br][br]決定キーでアプリを終了します。[end]", null, null
      },
      new JavaString[]{
          "　[br][br]◆サイト接続確認[br][br]サイトに接続すると、アプリが終了し、[br]記録していない進行情報が[br]失われてしまいます。[br][br]セーブしてから接続しますか？[end]", "はい", "いいえ"
      },
      new JavaString[]{
          "　[br][br]◆終了確認[br][br]このままアプリを終了すると、[br]記録していない進行情報が[br]失われてしまいます。[br][br]セーブしてから終了しますか？[end]", "はい", "いいえ"
      }
    };
}


/* Location:              D:\Users\Kirito\Desktop\Layton_Motdm\tools\DeathlyMirrorPortableEmu\Chapters\Emulator\Games\deathmirror\bin\deathmirror.jar!\\\u.class
 * Java compiler version: 1 (45.3)
 * JD-Core Version:       1.1.3
 */