import React, { useState } from "react";
import styles from "./Orders.module.scss";

import Card from "../../components/Card/Card";

function Orders() {
    const [orders, setOrders] = useState([
        {
            id: 1,
            price: 650,
            items: [
                {
                    id: "1",
                    title: "Вигвам 1, классический",
                    price: 300,
                    imageUrl: "/img/wigwams/1.jpg",
                },
                {
                    id: "2",
                    title: "Вигвам 2, модернизированный",
                    price: 350,
                    imageUrl: "/img/wigwams/2.jpg",
                },
            ],
        },
    ]);
    const [isLoading, setIsLoading] = useState(false);

    return (
        <div className="content p-40">
            <div className="d-flex align-center justify-between mb-40">
                <h1>Мои заказы</h1>
            </div>

            <div className={styles.orders}>
                {(isLoading ? [...Array(8)] : orders).map((item, index) => (
                    <div
                        key={index}
                        className={styles.order}>
                        <p className={styles.info}>
                            Заказ {item.id}. Общая цена: {item.price}
                        </p>
                        <div className={styles.list}>
                            {(isLoading ? [...Array(8)] : item.items).map(
                                (data, ind) => (
                                    <Card
                                        key={ind}
                                        loading={isLoading}
                                        {...data}
                                    />
                                )
                            )}
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default Orders;
