var express = require('express');
var bodyParser = require('body-parser');
var index_post = require('./routes/index_post');
var app = express();

var dt = new Date();
// 日本の時間に修正
dt.setTime(dt.getTime() + 32400000); //1000*60*60*9(hour)
var year = dt.getFullYear();

app.use(bodyParser.urlencoded({extended: true}));

app.set('view engine', 'jade');
app.set('views', __dirname + '/views');

app.get('/', function(req,res){
	res.render('index', { title: '作業日報', year: year});
});

app.get('/list/:id',function(req,res){
	console.log(req.params.id);
	index_post.showlist(req.params.id,res);
});

app.get('/list/delete/:id', function(req,res){
	index_post.deletelist(req.params.id,res);	
});
app.get('/list', index_post.list);
app.post('/', index_post.index);

app.listen(8080);