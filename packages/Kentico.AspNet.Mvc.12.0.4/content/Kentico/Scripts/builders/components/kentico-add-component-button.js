/*! Built with http://stenciljs.com */
const{h:t}=window.components;class o{constructor(){this.openComponentListHandler=(t=>{t.stopPropagation(),this.openComponentList.emit()})}render(){return t("div",{class:"ktc-component-button"},t("a",{"data-kentico-add-component":"",class:{"ktc-primary":this.primary,"ktc-default":!this.primary},onClick:this.openComponentListHandler},t("i",{"aria-hidden":"true",title:this.tooltip,class:"icon-plus"})))}static get is(){return"kentico-add-component-button"}static get properties(){return{primary:{type:Boolean,attr:"primary"},tooltip:{type:String,attr:"tooltip"}}}static get events(){return[{name:"openComponentList",method:"openComponentList",bubbles:!0,cancelable:!0,composed:!0}]}static get style(){return"kentico-add-component-button:hover .ktc-component-button,kentico-add-component-button[is-active=true] .ktc-component-button{opacity:1}kentico-add-component-button .ktc-component-button{opacity:.3}kentico-add-component-button .ktc-component-button [class*=\" icon-\"],kentico-add-component-button .ktc-component-button [class^=icon-]{font-family:Core-icons;display:inline-block;speak:none;font-style:normal;font-weight:400;font-variant:normal;text-transform:none;line-height:1;font-size:16px;-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;background-image:none}kentico-add-component-button .ktc-component-button [class^=icon-]:before{content:\"\\e619\"}kentico-add-component-button .ktc-component-button .ktc-icon-only:before{content:none}kentico-add-component-button .ktc-component-button *{cursor:pointer}kentico-add-component-button .ktc-component-button a{display:table;border-radius:3px;padding:8px;text-decoration:none}kentico-add-component-button .ktc-component-button a.ktc-default{background-color:#403e3d}kentico-add-component-button .ktc-component-button a.ktc-primary{background-color:#0f6194}kentico-add-component-button .ktc-component-button a .icon-plus{color:#fff;font-size:24px;font-weight:700;display:table-cell}kentico-add-component-button .ktc-component-button a .icon-plus:before{content:\"\\e62f\"}"}}export{o as KenticoAddComponentButton};