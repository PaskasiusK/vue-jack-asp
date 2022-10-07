<template>
    <div class="w-100 d-flex justify-content-center my-4 opacity-0">
        <div id="cards" style="width:500px;" class="rounded px-4 py-3 mt-n3 text-center gradient text-white">
        <h1>Bitcoin Price Index</h1>
        <div v-for="c in currency" v-bind:key="c" class="currency">
            {{ c.description }}:
            <span class="lighten">
                <span v-html="c.symbol"></span>{{ c.rate_float}}
            </span>
        </div>
    </div>

    </div>
</template>
<script>
export default {
    name: 'CurrencyCard',
    props: ["currency"]
}
</script>
<style scoped>
    .gradient{
       background: linear-gradient(90deg, rgba(5, 2, 52, 1) 0%, rgba(9, 9, 121, 1) 0%, rgba(0, 255, 218, 1) 100%);
    }
    p,label,h1,h2,h3,h4,h5,h6,a,router-link {
        font-family: 'Poppins', sans-serif;
    }
    h1{
        font-weight: bold;
    }
</style>