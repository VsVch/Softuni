function solution(num) {

    let finctionName = 'add' + num;

    finctionName = function sum(secNum){
        return secNum + num;
    }
    return finctionName;

}