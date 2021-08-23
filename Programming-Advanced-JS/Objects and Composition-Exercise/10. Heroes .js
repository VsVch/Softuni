function solve() {
    return {
        mage,
        fighter,
    }

    function fighter(name) {
        
        const fighterHero = {
            name: name,
            health: 100,
            stamina: 100,
            fight () {
                this.stamina -= 1;
                console.log(`${this.name} slashes at the foe!`);
            }
        }
        return fighterHero;
    };

    function mage(name) {

        const mageHero = {
            name: name,
            health: 100,
            mana: 100,
            cast(spell) {
                this.mana -= 1;
                console.log(`${this.name} cast ${spell}`);
            }
        }
        return mageHero;

    }

}