var value = "tracker/tracker.aspx?referrer=" + escape(document.referrer);
value += "&location=" + escape(document.location.href);
var html_doc = document.getElementsByTagName("head").item(0);
var scriptTag = document.createElement("SCRIPT");
scriptTag.src = value;
html_doc.appendChild(scriptTag);
