mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
    console.log("Hello, world!");
  },

  GiveMePlayerData: function () {
    myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
    myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));
  },

  RateGame: function () {
    ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
  },

  SaveExtern: function(date) {
    var dateString = UTF8ToString(date);
    var myobj = JSON.parse(dateString);
    player.setData(myobj);
  },

  LoadExtern: function() {
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
    });
  },

  SetToLeaderboard : function(value){
    ysdk.getLeaderboards()
      .then(lb => {
        // Без extraData
        lb.setLeaderboardScore('Height', value);
      });
  },

  GetLang : function (){
  	var lang = ysdk.environment.i8n.lang;
  	var bufferSize = lengthBytesUTF8(lang) + 1;
  	var buffer = _malloc(bufferSize);
  	stringToUTF8(lang, buffer, bufferSize);
  	return buffer;
  },

  ShowAdv : function(){
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          console.log("-----------closed--------");
          // some action after close
        },
        onError: function(error) {
          // some action on error
        }
      }
    })
  },

  AddCoinsExtern : function(value){
		ysdk.adv.showRewardedVideo({
        callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
      },
        onRewarded: () => {
					console.log('Rewarded!');
					myGameInstance.SendMessage("CoinManager", "AddCoins", value);
      },
        onClose: () => {
          console.log('Video ad closed.');
      },
        onError: (e) => {
          console.log('Error while open video ad:', e);
      }
    }
    })
  },

  BuyCrown: function(){
		payments.purchase({ id: 'crown' }).then(purchase => {
        // Покупка успешно совершена!
				myGameInstance.SendMessage("InApp", "SetCrownTrue");
    }).catch(err => {
        // Покупка не удалась: в консоли разработчика не добавлен товар с таким id,
        // пользователь не авторизовался, передумал и закрыл окно оплаты,
        // истекло отведённое на покупку время, не хватило денег и т. д.
    })
  },

  CheckCrown: function(){
  		var SHOW_ADS = true;
  		payments.getPurchases().then(purchases => {
          if (purchases.some(purchase => purchase.productID === 'crown')) {
  	          myGameInstance.SendMessage("InApp", "SetCrownTrue");
          }
      }).catch(err => {
          // Выбрасывает исключение USER_NOT_AUTHORIZED для неавторизованных пользователей.
      })
  },

});
