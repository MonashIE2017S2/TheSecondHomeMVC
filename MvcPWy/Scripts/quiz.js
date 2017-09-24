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
                type: "radiogroup", name: "kidGender", title: "What is the attendance status of this kid?", isRequired: true,
                colCount: 6, choices: ["Excellent(95%)", "Good(85%)", "Fair(75%)", "Not Good(60% or below)"]
            },
            {
                type: "radiogroup", name: "kidGender", title: "What is the grade status of this kid?", isRequired: true,
                colCount: 6, choices: ["Excellent(TOP 15%)", "Good(TOP 30%)", "Fair(TOP 60%)", "Not Good(Below 60%)"]
            },
            {
                type: "radiogroup", name: "kidGender", title: "Does the kid have a record of significant bad behavior?", isRequired: true,
                colCount: 6, choices: ["Many records", "Just one", "Never"]
            },
            {
                type: "radiogroup", name: "kidGender", title: "What is the gender of this kid?", isRequired: true,
                colCount: 6, choices: ["Male","Female"]
            },
            {
                type: "radiogroup", name: "Suburb", title: "Please select the area where your school is located.", isRequired: true, colCount: 6,
                choices: ["North-Eastern Victoria", "North-Western Victoria","South-Eastern Victoria","South-Western Victoria"]
            },
            {
                type: "radiogroup", name: "kidGender", title: "What type of school are you work in?", isRequired: true,
                colCount: 6, choices: ["Government", "Non-Government","Catholic","Indepentent"]
            },
            {
                type: "dropdown", name: "Suburb", title: "Please select the suburb where your school is located.", isRequired: true, colCount: 0,
                choices: keys
            },
            {
                type: "radiogroup", name: "Age", title: "Have you ever found any sign of domestic violence in the body of this kid?", isRequired: true, colCount: 0,
                choices: ["Yes", "No"]
            },
            {
                type: "radiogroup", name: "Age", title: "What is the family status of this kid?", isRequired: true, colCount: 0,
                choices: ["Single-Parent", "Two-parent Family", "Foster Family"]
            },
            {
                type: "dropdown", name: "Friends", title: "How many friends do the child have?", isRequired: true, colCount: 0,
                choices: ["Few Friend", "One or Two Friends", "Many Friends"]
            },
            {
                type: "radiogroup", name: "Sports", title: "Have you noticed that the child engaged in any sports?", isRequired: true,
                colCount: 4, choices: ["Yes", "Not Sure", "No"]
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
        if ((parseInt(emotion) <= 2 && (friends === "Few Friend" || friends === "Not Sure" || friends === "One or Two Friends") )|| nillIncomePercent < 20) {

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

