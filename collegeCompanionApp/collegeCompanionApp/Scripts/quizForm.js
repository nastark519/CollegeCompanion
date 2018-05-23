$('#submit').click(start);

function start() {
    var ans1 = parseInt($("input:radio[name=q1]:checked").val());
    var ans2 = parseInt($("input:radio[name=q2]:checked").val());
    var ans3 = parseInt($("input:radio[name=q3]:checked").val());
    var ans4 = parseInt($("input:radio[name=q4]:checked").val());
    var ans4 = parseInt($("input:radio[name=q4]:checked").val());
    var ans5 = parseInt($("input:radio[name=q5]:checked").val());
    var ans6 = parseInt($("input:radio[name=q6]:checked").val());
    var ans7 = parseInt($("input:radio[name=q7]:checked").val());
    var ans8 = parseInt($("input:radio[name=q8]:checked").val());
    var ans9 = parseInt($("input:radio[name=q9]:checked").val());
    var ans10 = parseInt($("input:radio[name=q10]:checked").val());
    var ans11 = parseInt($("input:radio[name=q11]:checked").val());
    var ans12 = parseInt($("input:radio[name=q12]:checked").val());
    var ans13 = parseInt($("input:radio[name=q13]:checked").val());
    var ans14 = parseInt($("input:radio[name=q14]:checked").val());
    var ans15 = parseInt($("input:radio[name=q15]:checked").val());
    var ans16 = parseInt($("input:radio[name=q16]:checked").val());
    var ans17 = parseInt($("input:radio[name=q17]:checked").val());
    var ans18 = parseInt($("input:radio[name=q18]:checked").val());
    var ans19 = parseInt($("input:radio[name=q19]:checked").val());
    var ans20 = parseInt($("input:radio[name=q20]:checked").val());
    var ans21 = parseInt($("input:radio[name=q21]:checked").val());
    var ans22 = parseInt($("input:radio[name=q22]:checked").val());
    var ans23 = parseInt($("input:radio[name=q23]:checked").val());
    var ans24 = parseInt($("input:radio[name=q24]:checked").val());
    var ans25 = parseInt($("input:radio[name=q25]:checked").val());
    var ans26 = parseInt($("input:radio[name=q26]:checked").val());
    var ans27 = parseInt($("input:radio[name=q27]:checked").val());
    var ans28 = parseInt($("input:radio[name=q28]:checked").val());
    var test = nullTest(ans1, ans2, ans3, ans4, ans5, ans6, ans7, ans8, ans9, ans10, ans11, ans12, ans13, ans14, ans15, ans16, ans17, ans18, ans19, ans20, ans21, ans22, ans23, ans24, ans25, ans26, ans27, ans28);

    if (test != false) {
        var bsTotal = bsFields(ans2, ans9, ans16, ans20);
        var medTotal = medFields(ans7, ans11, ans19, ans27);
        var buisTotal = buisFields(ans1, ans6, ans14, ans26);
        var edTotal = edFields(ans3, ans21, ans23, ans25);
        var compTotal = compFields(ans10, ans15, ans17, ans24);
        var socialTotal = socialFields(ans4, ans8, ans12, ans18);
        var natTotal = natFields(ans5, ans13, ans22, ans28);

        var category = findHighest(bsTotal, medTotal, buisTotal, edTotal, compTotal, socialTotal, natTotal);

        popUpResults(category);
    }
}

function bsFields(ans2, ans9, ans16, ans20) {
    var bsTotal = ans2 + ans9 + ans16 + ans20;
    return bsTotal;
}

function medFields(ans7, ans11, ans19, ans27) {
    var medTotal = ans7 + ans11 + ans19 + ans27;
    return medTotal;
}

function buisFields(ans1, ans6, ans14, ans26) {
    var buisTotal = ans1 + ans6 + ans14 + ans26;
    return buisTotal;
}

function edFields(ans3, ans21, ans23, ans25) {
    var edTotal = ans3 + ans21 + ans23 + ans25;
    return edTotal;
}

function compFields(ans10, ans15, ans17, ans24) {
    var compTotal = ans10 + ans15 + ans17 + ans24;
    return compTotal;
}

function socialFields(ans4, ans8, ans12, ans18) {
    var socialTotal = ans4 + ans8 + ans12 + ans18;
    return socialTotal;
}

function natFields(ans5, ans13, ans22, ans28) {
    var natTotal = ans5 + ans13 + ans22 + ans28;
    return natTotal;
}

function findHighest(bsTotal, medTotal, buisTotal, edTotal, compTotal, socialTotal, natTotal) {
    var highest = bsTotal;
    var category = "None";
    if (highest < medTotal) {
        highest = medTotal;
        category = "Medical Sciences";
    }
    if (highest < buisTotal) {
        highest = buisTotal;
        category = "Business Administration";
    }
    if (highest < edTotal) {
        highest = edTotal;
        category = "Education";
    }
    if (highest < compTotal) {
        highest = compTotal;
        category = "Engineering, Computer Science & Technology";
    }
    if (highest < socialTotal) {
        highest = socialTotal;
        category = "Social Sciences & Humanities";
    }
    if (highest < natTotal) {
        highest = natTotal;
        category = "Natural Sciences & Life Sciences";
    }
    if (highest < bsTotal) {
        highest = bsTotal;
        category = "Behavioral Sciences";
    }
    return category;
}

function popUpResults(category) {
    if (category == "Medical Sciences") {
        alert(
            'You are best suited to Medical Sciences:\n' 
            + 'Biological And Biomedical Science\n'
            + 'Health Professions And Related Programs\n'
            + 'Nursing\n'
            + 'Physical Therapy'
        );
    }
    if (category == "Business Administration") {
        alert(
            'You are best suited to Business Administration:\n'
            + 'Business, Management, Marketing, And Related Support Services\n'
            + 'Entrepreneurship\n'
            + 'Legal Professions And Studies\n'
            + 'Public Administration And Social Service Professions\n'
            + 'Transportation And Materials Moving'
        );
    }
    if (category == "Education") {
        alert(
            'You are best suited to Education:\n'
            + 'Education\n'
            + 'English Language And Literature/Letters\n'
            + 'Library Science\n'
            + 'History\n'
            + 'Mathematics And Statistics\n'
            + 'Special Needs Education'
        );
    }
    if (category == "Engineering, Computer Science & Technology") {
        alert(
            'You are best suited to Engineering, Computer Science & Technology:\n'
            + 'Architecture And Related Services\n'
            + 'Communications Technologies/Technicians And Support Services\n'
            + 'Computer And Information Sciences And Support Services\n'
            + 'Construction Trades\n'
            + 'Engineering\n'
            + 'Engineering Technologies And Engineering-Related Fields\n'
            + 'Mechanic And Repair Technologies/Technicians\n'
            + 'Military Technologies And Applied Sciences\n'
            + 'Science Technologies/Technicians'
        );
    }
    if (category == "Social Sciences & Humanities") {
        alert(
            'You are best suited to Social Sciences & Humanities:\n'
            + 'Communication, Journalism, And Related Programs\n'
            + 'Foreign Languages, Literatures, And Linguistics\n'
            + 'Homeland Security, Law Enforcement, Firefighting And Related Protective Services\n'
            + 'Liberal Arts And Sciences, General Studies And Humanities\n'
            + 'Personal And Culinary Services\n'
            + 'Philosophy And Religious Studies\n'
            + 'Precision Production\n'
            + 'Theology And Religious Vocations\n'
            + 'Visual And Performing Arts'
        );
    }
    if (category == "Natural Sciences & Life Sciences") {
        alert(
            'You are best suited to Natural Sciences & Life Sciences:\n'
            + 'Agriculture, Agriculture Operations, And Related Sciences\n'
            + 'Biological And Biomedical Sciences\n'
            + 'Natural Resources And Conservation\n'
            + 'Parks, Recreation, Leisure, And Fitness Studies\n'
            + 'Physical Sciences'
        );
    }
    if (category == "Behavioral Sciences") {
        alert(
            'You are best suited to Behavioral Sciences:\n'
            + 'Area, Ethnic, Cultural, Gender, And Group Studies\n'
            + 'Family And Consumer Sciences/Human Sciences\n'
            + 'Physical Sciences\n'
            + 'Psychology\n'
            + 'Social Sciences'
        );
    }
}

function nullTest(ans1, ans2, ans3, ans4, ans5, ans6, ans7, ans8, ans9, ans10, ans11, ans12, ans13, ans14, ans15, ans16, ans17, ans18, ans19, ans20, ans21, ans22, ans23, ans24, ans25, ans26, ans27, ans28) {

    var ansArray = [ans1, ans2, ans3, ans4, ans5, ans6, ans7, ans8, ans9, ans10,
        ans11, ans12, ans13, ans14, ans15, ans16, ans17, ans18, ans19, ans20,
        ans21, ans22, ans23, ans24, ans25, ans26, ans27, ans28];

    ansArray.forEach(function (item, index, array) {
        if (item == null || item == 'undefined') {
            $('#error').html("Please check your quiz and fill out all the questions.");
            return false;
        } else {
            return true;
        }
    });
}
