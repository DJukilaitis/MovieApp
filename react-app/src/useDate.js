export const useDate=(date)=>{
    return new Intl.DateTimeFormat("lt-LT").format(new Date (date));
}