export const setLimits = (e, val) => {
    if(val > 100)
        e.target.value = 100;
    else if(val < 0)
        e.target.value = 0;
}