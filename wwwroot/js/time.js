function TimeCounter(date) {
	var t = date;
	var days = parseInt(t / 86400);
	t = t - (days * 86400);
	var hours = parseInt(t / 3600);
	t = t - (hours * 3600);
	var minutes = parseInt(t / 60);
	t = t - (minutes * 60);
	var content = "";
	if (days) content += days + ":";
	if (hours || days) { if (content) content += ", "; content += hours + ":"; }
	if (content) content += ", "; content += minutes + ":" + t;
	return content;
}