/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}", "./node_modules/flowbite/**/*.js"],
  theme: {
    extend: {
      colors: {
        dark: "#252525",
        omg_red: "#EC1A23"
      },
      textUnderlineOffset: {
        5: "5px",
        6: "6px",
        7: "7px",
        10: "10px"
      },
      borderWidth: {
        5: "5px",
        6: "6px",
        7: "7px"
      },
      backgroundImage: {
        'main_hero': "url(src/assets/img/omg-hero.jpg)",
        'bg-gokhan-sarikurt': "url(src/assets/img/gokhan-sarikurt.jpg)",
        'bg-serdar-sarikurt': "url(src/assets/img/serdar-sarikurt.jpg)",
        'bg-mehmet-baltaci': "url(src/assets/img/mehmet-baltaci.jpg)",
      }
    },
  },
  plugins: [
    require('flowbite/plugin')
  ],
}

