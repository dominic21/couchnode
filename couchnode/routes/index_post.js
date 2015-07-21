var couchbase = require('couchbase');
var cluster = new couchbase.Cluster('couchbase://192.168.21.201:8091');
require('date-utils')

//var bucket = cluster.openBucket('Daily_work_report');
//var bucket = cluster.openBucket('beer-sample');
var bucket = cluster.openBucket('default');

exports.index = function(req,res){
	var titlevalue = req.body.Period_title;
	var classification = new Array();
	
	if(req.body.Period_title == ''){
	titlevalue = '無題';
	};
	
	classification = req.body.Period_classification;
	console.log(req.body.Period_classification);
	
	if(req.body.Period_classification == undefined){
	classification = '無し';
	};
	
	var jsonvalue = {"Period_start":req.body.Period_start_year + '年' + req.body.Period_start_month+ '月' + req.body.Period_start_day + '日', 
	"Period_end":req.body.Period_end_year + '年' + req.body.Period_end_month + '月' + req.body.Period_end_day + '日', 
	"Period_title":titlevalue, 
	"Period_worker":req.body.Period_worker,
	"Period_location":req.body.Period_location, 
	"Period_time":req.body.Period_time + '時間', 
	"Period_customer":req.body.Period_customer, 
	"Period_requester":req.body.Period_requester, 
	"Period_classification":[classification], 
	"Period_content":req.body.Period_content, 
	"Period_remarks":req.body.Period_remarks,};

	console.log(JSON.stringify(jsonvalue, null, "\t"));
	var Incremental = 1
	//カウチベース内でのインクリメント（++）操作
	bucket.counter('id',Incremental,function(err,res){
		if(err){
		console.log(err);
		}else{
			var Key = res.value;
			var dt = new Date();
			var formatdate = dt.toFormat("YYYY/MM/DD");
			jsonvalue.type = "report";
			jsonvalue.createdate = formatdate;
		};
		//カウチベース追加操作
		bucket.insert(Key.toString(), jsonvalue,function(err,res){
			console.log('Data Insert sucsses!' + jsonvalue + Key.toString());
			
			//一回見に行かないと履歴に表示されない（なぜ？）
			var ViewQuery = couchbase.ViewQuery;
			var query = ViewQuery.from('listtest', 'list_json');
			bucket.query(query, function (err, res, meta){
			});
		});
	});
	
	if(req.body.Period_start_year === undefined){
		res.render('index', { title: '作業日報'});
	}else{
		res.render('index', { title: '作業日報', year: req.body.Period_start_year});
	}
};


exports.list = function(req,resp){
	var ViewQuery = couchbase.ViewQuery;
	//order 1=昇順 2=降順
	var query = ViewQuery.from('listtest', 'list_json').order(2);
	var jsonarray = new Array();
	bucket.query(query, function (err, res, meta) {
    	if (err) {
        	console.error('View query failed:', err);
        	res.render('err', {title: 'エラー'});
        	return;
    	}
    	console.log('Found', meta.total_rows, 'results:', res);
    	
    	for(var i = 0; i < res.length; i++){
    	
    		var json = {
    		id: res[i].id,
    		create_date: res[i].key,
    		value: res[i].value
    		};
    		
    		jsonarray[i] = json;
    	};
    		console.log('Createjson');
    		console.log(jsonarray);
			resp.render('list', {title: '履歴', histry: jsonarray});
	});

};

exports.showlist = function(id,res){
	bucket.get(id, function(err,json){
	    	if (err) {
        	console.error('View query failed:', err);
        	res.render('err', {title: 'エラー'});
        	return;
    	}
		console.log('showlistid and json' + id);
		console.log(json.value);
		res.render('showlist', {title: json.value.Period_title, json: json.value});
	});
};

exports.deletelist = function(id,resp){
	bucket.remove(id,function(err,res){
		if(err){
			console.log('remove failed', err);
			return;
		}
		console.log('success!',res);
		//listに飛ばすと消えてないため仕方なく登録画面に飛ばしています
		resp.redirect('/');
	});
};

exports.createid = function(){
	bucket.get('id',function(err,res){
		if(err){
			console.log('Create id');
			bucket.insert('id', '0', function(err,res){
			if(err){
				console.log('create id failed');
				return;
			}
			console.log('create id sucsses!');
		});
		}
	});
};

/*
exports.serchlist = function(){
	var ViewQuery = couchbase.ViewQuery;
	//order 1=昇順 2=降順
	var query = ViewQuery.from('listtest', 'list_json').order(2);
	var jsonarray = new Array();
	bucket.query(query, function (err, res, meta) {
    	if (err) {
        	console.error('View query failed:', err);
        	res.render('err', {title: 'エラー'});
        	return;
    	}
    	console.log('Found', meta.total_rows, 'results:', res);
    	
    	for(var i = 0; i < res.length; i++){
    		if(){
    			var json = {
    			id: res[i].id,
    			create_date: res[i].key,
    			value: res[i].value
    			};
    		
    			jsonarray[i] = json;
    		}
    	};
    		console.log('Createjson');
    		console.log(jsonarray);
			resp.render('list', {title: '履歴', histry: jsonarray});
	});
};
*/