var couchbase = require('couchbase');
var cluster = new couchbase.Cluster('couchbase://10.0.1.143:8091');
var bucket = cluster.openBucket('serviceReport');

bucket.insert('id', '1',function(err,res){
console.log('sucsses!');
});