<template>
<div :class="{ loader: true, fadeout: !isLoading }"> 
  <div class="loading-box">
    <div class="lds-roller">
      <div></div>
      <div></div>
      <div></div>
      <div></div>
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
  animation: fadeout 1s forwards;
}

@keyframes fadeout {
  to {
    opacity: 0;
    visibility: hidden;
  }
}
.lds-roller {
  top : 40%;
  display: inline-block;
  position: relative;
  width: 80px;
  height: 80px;
}
.lds-roller div {
  animation: lds-roller 1.2s cubic-bezier(0.5, 0, 0.5, 1) infinite;
  transform-origin: 40px 40px;
}
.lds-roller div:after {
  content: " ";
  display: block;
  position: absolute;
  width: 7px;
  height: 7px;
  border-radius: 50%;
  margin: -4px 0 0 -4px;
}
.lds-roller div:nth-child(1) {
  animation-delay: -0.036s;
  background: rgb(106, 99, 182);
}
.lds-roller div:nth-child(1):after {
  background: rgb(106, 99, 182);
  top: 63px;
  left: 63px;
}
.lds-roller div:nth-child(2) {
  animation-delay: -0.072s;
  background: rgb(99, 124, 181);
}
.lds-roller div:nth-child(2):after {
  top: 68px;
  left: 56px;
  background: rgb(99, 124, 181);
}
.lds-roller div:nth-child(3) {
  animation-delay: -0.108s;
  background: rgb(100, 146, 172);
}
.lds-roller div:nth-child(3):after {
  top: 71px;
  left: 48px;
  background: rgb(100, 146, 172);
}
.lds-roller div:nth-child(4) {
  animation-delay: -0.144s;
  background: rgb(132, 155, 135);
}
.lds-roller div:nth-child(4):after {
  top: 72px;
  left: 40px;
  background: rgb(132, 155, 135);
}
.lds-roller div:nth-child(5) {
  animation-delay: -0.18s;
  background: rgb(171, 189, 129);
}
.lds-roller div:nth-child(5):after {
  top: 71px;
  left: 32px;
  background: rgb(171, 189, 129);
}
.lds-roller div:nth-child(6) {
  animation-delay: -0.216s;
  background: rgb(248, 178, 106);
}
.lds-roller div:nth-child(6):after {
  top: 68px;
  left: 24px;
  background: rgb(248, 178, 106);
}
.lds-roller div:nth-child(7) {
  animation-delay: -0.252s;
  background: rgb(244, 126, 96);
}
.lds-roller div:nth-child(7):after {
  top: 63px;
  left: 17px;
  background: rgb(244, 126, 96);
}
.lds-roller div:nth-child(8) {
  animation-delay: -0.288s;
  background: rgb(225, 91, 100);
}
.lds-roller div:nth-child(8):after {
  top: 56px;
  left: 12px;
  background: rgb(225, 91, 100);
}
@keyframes lds-roller {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
</style>
