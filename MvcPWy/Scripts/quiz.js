/* Created by yang and roshan
*  Date : 06-Sep-2017
*  Logic of the questionnaire is handled
* 
*/


Survey.Survey.cssType = "bootstrap";
Survey.defaultBootstrapCss.navigationButton = "btn btn-green";
// Initialize Firebase database 
var config = {
    apiKey: "AIzaSyBuZ3aZJOwa4Xwa3iJuLZe6WH0umz-brlc",
    authDomain: "thesecondhomedb.firebaseapp.com",
    databaseURL: "https://thesecondhomedb.firebaseio.com",
    projectId: "thesecondhomedb",
    storageBucket: "thesecondhomedb.appspot.com",
    messagingSenderId: "1047254460760"
};
firebase.initializeApp(config);

var keys=[];

var database = firebase.database();


database.ref().on("value", function (snap) {
//pull entries from database
    var obj = snap.val();
    for (x in obj) {
        keys.push(x);
    }

    window.survey = new Survey.Model({
        questions: [
            {
                type: "radiogroup", name: "kidGender", title: "Please select the gender of the child", isRequired: true,
                colCount: 4, choices: ["Boy", "Girl"]
            },
            {
                type: "dropdown", name: "Age", title: "What is the age of the child?", isRequired: true, colCount: 0,
                choices: ["0-6", "6-10", "10-14", "14-18"]
            },
            {
                type: "dropdown", name: "Friends", title: "How many friends do the child have?", isRequired: false, colCount: 0,
                choices: ["Few Friend", "One or Two Friends", "Many Friends", "Not Sure"]
            },
            {
                type: "checkbox", name: "Sports", title: "Have you noticed that the child engaged in any sports?", isRequired: false,
                colCount: 4, choices: ["Footy", "Basketball", "Tennis", "Swimming", "Skating", "Cycling"]
            },
            {
                type: "dropdown", name: "SocialEvents", title: "Does the child participate in community or church activities?", isRequired: false, colCount: 0,
                choices: ["Never", "Occasionally", "Frequently", "Not Sure"]
            },
            {
                type: "rating", name: "Emotion", title: "What do you think of the child's daily emotion?",
                mininumRateDescription: "Depressed", maximumRateDescription: "Optimistic"
            },
            {
                type: "dropdown", name: "Suburb", title: "Choose your suburb", isRequired: false, colCount: 0,
                choices: keys
            }

        ]
    });



    survey.onComplete.add(function (result) {

        var emotion = result.data['Emotion'];
        var socialEvents = result.data['SocialEvents'];
        var sports = result.data['Sports'];
        var friends = result.data['Friends'];
        var age = result.data['Age'];
        var gender = result.data['kidGender'];
        var suburb = result.data['Suburb'];


        var $alert1 = $("#alert1");
        var $alert2 = $("#alert2");
        var $alertSad = $("#alert-sad");
        var $alertHappy = $("#alert-happy");
        var $alertOK = $("#ok");

        //Find low income suburb
        var nillIncomePercent = obj[suburb]["TotalCount"] / obj[suburb]["nillIncomeCount"];
        


        //Calculate vulnerability of child
        if ((parseInt(emotion) <= 2 && (friends == "Few Friend" || friends == "Not Sure" || friends == "One or Two Friends") )|| nillIncomePercent < 20) {

            $alertSad.show();

            $alert1.stop().fadeIn(300);
            //$alertSad.css("visibility","hidden");
        }
        else {
            $alertHappy.show();
            $alert2.stop().fadeIn(300);
            //$alertHappy.css("visibility","hidden");

        }

        $(".ok").click(function () {
            $("#alertSad").hide();
            $("$alertHappy").hide();

        });

    });



    $("#surveyElement").Survey({ model: survey });
});

