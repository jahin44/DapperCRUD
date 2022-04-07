<template>
<div :class="{ loader: true, fadeout: !isLoading }"> 
  <div class="loading-box">
    <div class="lds-ellipsis">
      <div></div>
      <div></div>
      <div></div>
      <div></div>
    </div>
  </div>
  </div>
</template>

<script>
export default{
  name: "TheLoader",
  props: ["isLoading"]
};
</script>

<style scoped>
.loading-box{
  position: fixed;
  width: 100%;
  height: 100%;
  margin: auto;
  background :#ffffff;
  z-index: 999;
  left: 0px;
  right: 0px;
  text-align: center;
  padding: 10px;
}
.fadeout {
  animation: fadeout 2s forwards;
}

@keyframes fadeout {
  to {
    opacity: 0;
    visibility: hidden;
  }
}
.lds-ellipsis {
  display: inline-block;
  position: relative;
  left:10%;
  top:40%;
  margin: -25% 0 0 -25%;
}
.lds-ellipsis div {
  position: absolute;
  top: 50%;
  width: 13px;
  height: 13px;
  border-radius: 50%;
  background: #880808	;
  animation-timing-function: cubic-bezier(0, 1, 1, 0);
}
.lds-ellipsis div:nth-child(1) {
  left: 8px;
  animation: lds-ellipsis1 0.6s infinite;
}
.lds-ellipsis div:nth-child(2) {
  left: 8px;
  animation: lds-ellipsis2 0.6s infinite;
}
.lds-ellipsis div:nth-child(3) {
  left: 32px;
  animation: lds-ellipsis2 0.6s infinite;
}
.lds-ellipsis div:nth-child(4) {
  left: 56px;
  animation: lds-ellipsis3 0.6s infinite;
}
@keyframes lds-ellipsis1 {
  0% {
    transform: scale(0);
  }
  100% {
    transform: scale(1);
  }
}
@keyframes lds-ellipsis3 {
  0% {
    transform: scale(1);
  }
  100% {
    transform: scale(0);
  }
}
@keyframes lds-ellipsis2 {
  0% {
    transform: translate(0, 0);
  }
  100% {
    transform: translate(24px, 0);
  }
}
</style>
