var msnryObj;
var pageContentH = 0;

window.onload = function()
{
  if($(".adsensebox").length || $(".adsense_infeed").length){
    adsenseSet();
  }
  if($("#recommend1").length){
    displayRecommend();
  }
  if($("article").length){
    setReadMore();
  }
};

$(function(){
  $("#footer").load("./footer/footer.html");
});

function setReadMore() {
  $(function () {
      $('article').readmore({
          collapsedHeight: 200,
          speed: 100,
          moreLink: '<a href="#" >続きを見る</a>',
          lessLink: '<a href="#" >閉じる</a>'
      });
  });
}


// laboを追加したらrecommendAll及び、relatedListに追加すること！
var relatedList = [];
var recommendAll = ["a001", "a002", "a003", "a004", "a005", "a006", "a007", "a008", "a009", "a010",
                    "a011", "a012", "a013" , "a014", "a015", "a016", "a017", "a018", "a019", "a020",
                    "a021", "a022", "a023", "a024"];

// 対象のページ、一つ目のレコメンド、二つ目のレコメンド
// Webでスロットゲームをつくろう！,LINE BOTでお店ランキング表示サービスをつくろう！,【自分専用ボット】定型メールはLINEでらくらく送信！
relatedList.push(["a001", "a017", "a020"]);
// 【住所⇔緯度・経度】位置情報の相互変換,【無料】一括de逆コーディングツール（緯度経度→住所）,【月額制】一括de逆ジオコーディングツール Pro（緯度経度→住所，住所→緯度経度）
relatedList.push(["a002", "a021", "a023"]);
// 台湾視察記～COMPUTEX TAIPEI 2016～,台湾視察記～COMPUTEX TAIPEI 2017～,台湾及び米国から感じるITの方向性
relatedList.push(["a003", "a006", "a018"]);
// Web版スマホ簡易ナビ, ドラゴンレーダー風ナビ ～エンジン編～,【無料】一括de逆コーディングツール（緯度経度→住所）
relatedList.push(["a004", "a008", "a021"]);
// REST APIを使ってみよう！, Google Maps APIでお店のランキング表示をしてみると,【住所⇔緯度・経度】位置情報の相互変換
relatedList.push(["a005", "a015", "a002"]);
// 台湾視察記～COMPUTEX TAIPEI 2017～,台湾視察記～COMPUTEX TAIPEI 2018～,台湾及び米国から感じるITの方向性
relatedList.push(["a006", "a013", "a018"]);
// ドラゴンレーダー風ナビ ～デザイン編～,ドラゴンレーダー風ナビ ～エンジン編～,【無料】一括de逆コーディングツール（緯度経度→住所）
relatedList.push(["a007", "a008", "a021"]);
// ドラゴンレーダー風ナビ ～エンジン編～,【リリース】タイ語翻訳AIカメラ for LINEBOT,【無料】一括de逆コーディングツール（緯度経度→住所）
relatedList.push(["a008", "a019", "a021"]);
// 話題の「スマートEX」を使ってみた,「第1回 AI・業務自動化展」レポート,台湾及び米国から感じるITの方向性
relatedList.push(["a009", "a010", "a018"]);
// 「第1回 AI・業務自動化展」レポート,IoT：Internet of Things（モノのインターネット）,台湾及び米国から感じるITの方向性
relatedList.push(["a010", "a011", "a018"]);
// IoT：Internet of Things（モノのインターネット）,台湾及び米国から感じるITの方向性,【自分専用ボット】定型メールはLINEでらくらく送信！
relatedList.push(["a011", "a018", "a020"]);
// NECタグ使ってみた件,話題の「スマートEX」を使ってみた,IoT：Internet of Things（モノのインターネット）
relatedList.push(["a012", "a009", "a011"]);
// 台湾視察記～COMPUTEX TAIPEI 2018～,台湾及び米国から感じるITの方向性,第1回 AI・業務自動化展」レポート
relatedList.push(["a013", "a018", "a010"]);
// Google Maps APIでエラー頻発？その原因は？,Google Maps APIでお店のランキング表示をしてみると,【住所⇔緯度・経度】位置情報の相互変換
relatedList.push(["a014", "a015", "a004"]);
// Google Maps APIでお店のランキング表示をしてみると,Google Maps APIでお店のランキング表示をしてみると[PHP & GAS編],LINE BOTでお店ランキング表示サービスをつくろう！
relatedList.push(["a015", "a016", "a017"]);
// Google Maps APIでお店のランキング表示をしてみると[PHP & GAS編],LINE BOTでお店ランキング表示サービスをつくろう！,【自分専用ボット】定型メールはLINEでらくらく送信！
relatedList.push(["a016", "a017", "a020"]);
// LINE BOTでお店ランキング表示サービスをつくろう！,【リリース】タイ語翻訳AIカメラ for LINEBOT,Webでスロットゲームをつくろう！
relatedList.push(["a017", "a019", "a001"]);
// 台湾及び米国から感じるITの方向性,第1回 AI・業務自動化展」レポート,IoT：Internet of Things（モノのインターネット）
relatedList.push(["a018", "a010", "a011"]);
// 【リリース】タイ語翻訳AIカメラ for LINEBOT,LINE BOTでお店ランキング表示サービスをつくろう！,【自分専用ボット】定型メールはLINEでらくらく送信！
relatedList.push(["a019", "a017", "a021"]);
//【自分専用ボット】定型メールはLINEでらくらく送信！,【自分専用ボット】LINEBOTのUI改造で使い勝手アップ大作戦！,LINE BOTでお店ランキング表示サービスをつくろう！
relatedList.push(["a020", "a022", "a017"]);
//【無料】一括de逆コーディングツール（緯度経度→住所）,【月額制】一括de逆ジオコーディングツール Pro（緯度経度→住所，住所→緯度経度）,【住所⇔緯度・経度】位置情報の相互変換
relatedList.push(["a021", "a023", "a002"]);
//【自分専用ボット】LINEBOTのUI改造で使い勝手アップ大作戦！,【自分専用ボット】定型メールはLINEでらくらく送信！,LINE BOTでお店ランキング表示サービスをつくろう！
relatedList.push(["a022", "a020", "a017"]);
//【月額制】一括de逆ジオコーディングツール Pro（緯度経度→住所，住所→緯度経度）,【FAQ】「一括de逆ジオコーディングツール Pro」のよくあるご質問,【無料】一括de逆コーディングツール（緯度経度→住所）
relatedList.push(["a023", "a024", "a021"]);
//【FAQ】「一括de逆ジオコーディングツール Pro」のよくあるご質問,【月額制】一括de逆ジオコーディングツール Pro（緯度経度→住所，住所→緯度経度）,【無料】一括de逆コーディングツール（緯度経度→住所）
relatedList.push(["a024", "a023", "a021"]);

function displayRecommend() {
  var data = window.location.href.split('/').pop().substring(0, 4);
  var result1 = null;
  var targetList = [];
  
  for (var i = 0; i < relatedList.length; i++) {
    if (relatedList[i][0] == data) {
      result1 = relatedList[i];
    }
  }
  for (i = 0; i < recommendAll.length; i++) {
    if (result1 ==null || (recommendAll[i] != result1[0] && recommendAll[i] != result1[1] && recommendAll[i] != result1[2])) {
      targetList.push(recommendAll[i]);
    }
  }
  
  if (result1 != null){
    $("#recommend1").load("./recommend/" + result1[1] + ".html");
    $("#recommend2").load("./recommend/" + result1[2] + ".html");
  }
  if (targetList.length != 0) {
    $("#recommend3").load("./recommend/" + targetList[Math.floor( Math.random() * targetList.length)] + ".html");
  }
  
  var latestData = recommendAll[recommendAll.length-1];
  if (data != latestData){
    $(".recommendbox").prepend("<div id='new_article'></div>");
    $(".recommendbox").prepend("<h3>新しい記事</h3>");
    $("#new_article").load("./recommend/" + latestData + ".html");
  }
}

function adsenseSet(){
  var domain = window.location.hostname;
  if (domain != "www.delta-ss.com"){
    $(".adsensebox").css("display","none");
    $(".adsense_infeed").css("display","none");
  }
}

var pagetopTimer = false;

$(document).ready(function() {

  var scrollTarget = null;
  if ($('body').get(0).scrollHeight > $('body').get(0).offsetHeight) {
    scrollTarget = $(window); 
  }

  var pagetop = $('.pagetop');
  scrollTarget.scroll(function () {
      if ($(this).scrollTop() > 100) {
        pagetop.fadeIn();
        if (pagetopTimer !== false) {
          clearTimeout(pagetopTimer);
        }
      pagetopTimer = setTimeout(function() {
        pagetop.fadeOut();
      }, 3000);
    } else {
      pagetop.fadeOut();
    }
  });

  pagetop.click(function () {
    $('html,body').animate({ scrollTop: 0 }, 500, 'swing');
    return false;
  });
});
