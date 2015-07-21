var couchbase = require('couchbase');
var cluster = new couchbase.Cluster('couchbase://192.168.21.201:8091');
var bucket = cluster.openBucket('default');

bucket.insert('id', '0',function(err,res){
console.log('sucsses!');
});